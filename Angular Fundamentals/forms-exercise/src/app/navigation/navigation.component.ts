import { AuthenticationService } from "./../authentication/authentication.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-navigation",
  templateUrl: "./navigation.component.html",
  styleUrls: ["./navigation.component.css"]
})
export class NavigationComponent implements OnInit {
  constructor(private auth: AuthenticationService) {}

  ngOnInit() {}

  logoutClick() {
    this.auth.logout().subscribe(res => {
      console.log(res);
      localStorage.removeItem("authtoken");
      localStorage.removeItem("username");
    });
  }
}
