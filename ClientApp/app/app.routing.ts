import { Routes, RouterModule } from '@angular/router';
import { EntrySelectionComponent } from "./entries/entrySelection.component";
import { AdminComponent } from "./admin/admin.component";
import { OverviewComponent } from "./admin/overview.component";
import { EntryAdminComponent } from "./admin/entryAdmin.component";
import { AuthenticationGuard } from "./auth/authentication.guard";
import { AuthenticationComponent } from "./auth/authentication.component";

const routes: Routes = [
    { path: "login", component: AuthenticationComponent },
    { path: "admin", redirectTo: "/admin/overview", pathMatch:"full" },
    {
        path: "admin", component: AdminComponent,
        canActivateChild: [AuthenticationGuard],
        children: [
            { path: "entries", component: EntryAdminComponent },
            { path: "overview", component: OverviewComponent },
            { path: "", component: OverviewComponent}
        ]
    },
    { path: "entries", component: EntrySelectionComponent },
    { path: "", component: EntrySelectionComponent }
    ]

export const RoutingConfig = RouterModule.forRoot(routes);