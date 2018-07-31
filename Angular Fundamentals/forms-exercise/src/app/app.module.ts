import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { NavigationComponent } from "./navigation/navigation.component";
import { LoginFormComponent } from "./navigation/login-form/login-form.component";
import { RegisterFormComponent } from "./navigation/register-form/register-form.component";
import { HomeComponent } from "./home/home.component";

import { AppRoutes } from "./app.routes";

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LoginFormComponent,
    RegisterFormComponent,
    HomeComponent
  ],
  imports: [BrowserModule, AppRoutes, FormsModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
