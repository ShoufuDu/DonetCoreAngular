import { GlossaryModule } from '../entries/glossary.module';
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AdminComponent } from "./admin.component";
import { OverviewComponent } from "./overview.component";
import { EntryAdminComponent } from "./entryAdmin.component";
import { EntryEditorComponent } from "./entryEditor.component";

@NgModule({
    imports: [BrowserModule, RouterModule, FormsModule,GlossaryModule],
    declarations: [AdminComponent, OverviewComponent,
        EntryAdminComponent,
        EntryEditorComponent]
})
export class AdminModule {}