import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Entry } from "../models/entry.model";

@Component({
    templateUrl: "entryAdmin.component.html"
})

export class EntryAdminComponent {
    constructor(private repo: Repository) { }

    tableMode: boolean = true;

    get entry(): Entry {
        return this.repo.entry;
    }

    selectEntry(id: number) {
        this.repo.getEntry(id);
    }

    saveEntry() {
        if (this.repo.entry.id == null) {
            this.repo.createEntry(this.repo.entry);
        }
        else {
            this.repo.replaceEntries(this.repo.entry);
        }

        this.clearEntry();
        this.tableMode = true;
    }

    deleteEntry(id: number) {
        this.repo.deleteEntry(id);
    }

    clearEntry() {
        this.repo.entry = new Entry();
        this.tableMode = true;
    }

    get entries(): Entry[] {
        if (this.repo.entries != null && this.repo.entries.length > 0) {
            let pageIndex = (this.repo.pagination.currentPage - 1)
                * this.repo.pagination.entriesPerPage;
            return this.repo.entries.slice(pageIndex,
                pageIndex + this.repo.pagination.entriesPerPage);
        }
    }
}