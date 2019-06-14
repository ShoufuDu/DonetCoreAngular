import { Component } from "@angular/core";
import { Repository } from "../models/repository";

@Component({
    selector: "entry-pagination",
    templateUrl: "pagination.component.html"
})

export class PaginationComponent {
    constructor(private repo: Repository) { }

    get current(): number {
        return this.repo.pagination.currentPage;
    }

    get pages(): number[] {
        if (this.repo.entries != null) {
            return Array(Math.ceil(this.repo.entries.length
                    / this.repo.pagination.entriesPerPage))
                .fill(0).map((x, i) => i + 1);
        }
        else {
            return [];
        }
    }

    changePage(newPage: number) {
        this.repo.pagination.currentPage = newPage;
    }
}