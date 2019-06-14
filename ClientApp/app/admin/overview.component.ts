import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Entry } from "../models/entry.model";

@Component({
    templateUrl: "overview.component.html"
})

export class OverviewComponent {
    constructor(private repo: Repository) {
    }

    get entries(): Entry[] {
        console.log(this.repo.entries.length+" entries");
        return this.repo.entries;
    }
}