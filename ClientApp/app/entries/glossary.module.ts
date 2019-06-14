import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { CategoryFilterComponent } from "./categoryFilter.component";
import { PaginationComponent } from "./pagination.component";
import { EntryListComponent } from "./entryList.component";
import { EntrySelectionComponent } from "./entrySelection.component";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";


@NgModule({
    declarations: [CategoryFilterComponent,
        PaginationComponent, EntryListComponent,
        EntrySelectionComponent],
    imports: [BrowserModule, RouterModule, FormsModule],
    exports: [EntrySelectionComponent,PaginationComponent,CategoryFilterComponent]
})

export class GlossaryModule {}