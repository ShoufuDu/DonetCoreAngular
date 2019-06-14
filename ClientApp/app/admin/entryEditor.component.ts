import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Entry } from "../models/entry.model";

@Component({
    selector:"admin-entry-editor",
    templateUrl: "entryEditor.component.html"
})

export class EntryEditorComponent {
    constructor(private repo: Repository) { }

    get entry(): Entry {
        return this.repo.entry;
    }
}