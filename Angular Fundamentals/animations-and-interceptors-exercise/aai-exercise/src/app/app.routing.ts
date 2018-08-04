import { MyFurnitureComponent } from "./my-furniture/my-furniture.component";
import { FurnitureDetailsComponent } from "./furniture-details/furniture-details.component";
import { CreateFurnitureComponent } from "./create-furniture/create-furniture.component";
import { AllFurnitureComponent } from "./all-furniture/all-furniture.component";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

// Components
import { HomeComponent } from "./home/home.component";
import { SigninComponent } from "./authentication/signin/signin.component";
import { SignupComponent } from "./authentication/signup/signup.component";

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "home" },
  { path: "home", component: HomeComponent },
  { path: "signin", component: SigninComponent },
  { path: "signup", component: SignupComponent },
  {
    path: "furniture",
    children: [
      {
        path: "all",
        component: AllFurnitureComponent
      },
      {
        path: "create",
        component: CreateFurnitureComponent
      },
      {
        path: "details/:id",
        component: FurnitureDetailsComponent
      },
      { path: "my", component: MyFurnitureComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
