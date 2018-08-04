import { FurnitureService } from "./furniture.service";
import { ErrorInterceptor } from "./interceptors/app.error.interceptor";
import { AuthInterceptor } from "./interceptors/app.auth.intercetor";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppRoutingModule } from "./app.routing";
import { ToastrModule } from "ngx-toastr";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ReactiveFormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { NavigationComponent } from "./navigation/navigation.component";
import { SigninComponent } from "./authentication/signin/signin.component";
import { SignupComponent } from "./authentication/signup/signup.component";
import { HomeComponent } from "./home/home.component";
import { AuthService } from "./authentication/auth.service";
import { AllFurnitureComponent } from "./all-furniture/all-furniture.component";
import { CreateFurnitureComponent } from "./create-furniture/create-furniture.component";
import { FurnitureDetailsComponent } from "./furniture-details/furniture-details.component";
import { MyFurnitureComponent } from "./my-furniture/my-furniture.component";

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    SigninComponent,
    SignupComponent,
    HomeComponent,
    AllFurnitureComponent,
    CreateFurnitureComponent,
    FurnitureDetailsComponent,
    MyFurnitureComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
    FurnitureService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
