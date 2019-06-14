import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Entry } from "../models/entry.model";

@Component({
    selector: "entry-list",
    templateUrl: "entryList.component.html"
})

export class EntryListComponent {
    constructor(private repo: Repository) { }

    get entries(): Entry[] {
        if (this.repo.entries != null && this.repo.entries.length > 0) {
            let pageIndex = (this.repo.pagination.currentPage - 1)
                * this.repo.pagination.entriesPerPage;
            return this.repo.entries.slice(pageIndex,
                pageIndex + this.repo.pagination.entriesPerPage);
        }
    }
}