export class Filter {
    sorted: boolean = true;
    category?: string;

    reset() {
        this.sorted = false;
        this.category = null;
    }
}

export class Pagination {
    entriesPerPage: number = 5;
    currentPage = 1;
}