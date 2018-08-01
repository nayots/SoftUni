import { AuthGuard } from "./guards/auth.guard";
import { RegisterFormComponent } from "./navigation/register-form/register-form.component";
import { LoginFormComponent } from "./navigation/login-form/login-form.component";
import { HomeComponent } from "./home/home.component";

import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";

const routes: Routes = [
  {
    path: "",
    component: HomeComponent,
    pathMatch: "full",
    canActivate: [AuthGuard]
  },
  { path: "login", component: LoginFormComponent },
  { path: "register", component: RegisterFormComponent }
];

const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);

export { AppRoutes };
