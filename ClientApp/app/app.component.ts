import { Component } from '@angular/core';
import { Repository } from "./models/repository";
import { Entry } from "./models/entry.model"
import { ErrorHandlerService } from "./errorHandler.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    private lastError: string[];
    constructor(private repo: Repository) { }

    get Entry(): Entry {
        return this.repo.entry;
    }

    get Entrys(): Entry[] {
        return this.repo.entries;
    }

    createEntry() {
        this.repo.createEntry(new Entry(0, "X-Ray Scuba Mask", "Watersports"));
    }

    replaceEntry() {
        let p = this.repo.entries[0];
        p.term = "Modified Entry";
        p.definition = "Modified Category";
        this.repo.replaceEntries(p);
    }

    deleteEntry() {
        this.repo.deleteEntry(3);
    }
}
