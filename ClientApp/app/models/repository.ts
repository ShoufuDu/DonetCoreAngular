import { Entry } from "./entry.model";
import { Injectable } from "@angular/core";
import { Http, RequestMethod, Request, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Filter, Pagination } from "./configClasses.repository";

const entriesUrl = "/api/entries";

@Injectable()
export class Repository {
    private filterObject = new Filter();
    private paginationObject = new Pagination();

    constructor(private http:Http) {
        this.filter.sorted = true;
        this.getEntries(true);
    }

    getEntry(id: number) {
        this.http.get("/api/entries/" + id)
            .subscribe(response => {
                this.entry = response.json();
                console.log("recv entries");
            });
    }

    getEntries(sorted = true) {
        let url = entriesUrl + "?sorted=" + this.filter.sorted;

        if (this.filter.category) {
            url += "&category=" + this.filter.category;
        }

        url += "&metadata=true";
        this.sendRequest(RequestMethod.Get, url)
            .subscribe(response => {
                this.entries = response.data;
                console.log(url);
                console.log(this.entries);
                this.categories = response.categories
                this.pagination.currentPage = 1;
            });
    }

    createEntry(entry: Entry) {
        let data = {
            name: entry.term,
            definition: entry.definition,
            category:entry.term.substring(0,1).toUpperCase()
        };

        this.sendRequest(RequestMethod.Post, entriesUrl, data)
            .subscribe(response => {
                entry.id = response;
                this.entries.push(entry);
            });
    }

    replaceEntries(entry: Entry) {
        let data = {
            name: entry.term,
            definition: entry.definition,
            category:entry.category
        };
        this.sendRequest(RequestMethod.Put, entriesUrl + "/" + entry.id, data)
            .subscribe(response => this.getEntries());
    }

    deleteEntry(id: number) {
        this.sendRequest(RequestMethod.Delete, entriesUrl + "/" + id)
            .subscribe(reponse => this.getEntries());
    }

    private sendRequest(verb: RequestMethod, url: string, data?: any): Observable<any> {
        console.log("send to " + url);
        return this.http.request(new Request({
            method: verb, url: url, body: data
        })).map(response => {
            return response.headers.get("Content-Length") != "0" ?
                response.json() : null;
            });
    }

    login(name: string, password: string): Observable<Response> {
        return this.http.post("/api/account/login",
            { name: name, password: password });
    }

    logout() {
        this.http.post("/api/account/logout", null).subscribe(response => { });
    }

    entry: Entry;
    entries: Entry[];
    categories: string[] = [];

    get filter(): Filter {
        return this.filterObject;
    }

    get pagination(): Pagination {
        return this.paginationObject;
    }
}