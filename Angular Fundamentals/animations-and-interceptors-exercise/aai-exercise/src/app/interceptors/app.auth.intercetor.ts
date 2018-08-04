import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import {
  HttpResponse,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from "@angular/common/http";
import { tap } from "rxjs/operators";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService, private router: Router) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const currentUser = JSON.parse(localStorage.getItem("currentUser"));
    if (currentUser && currentUser.token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.token}`
        }
      });
    }

    return next.handle(request).pipe(
      tap((res: HttpEvent<any>) => {
        if (
          res instanceof HttpResponse &&
          res.body.token &&
          res.url.endsWith("login")
        ) {
          console.log("Here 1");

          this.saveToken(res.body);
          this.toastr.success("Successful login!", "Logged in!");
          this.router.navigate(["/home"]);
        }

        if (
          res instanceof HttpResponse &&
          res.body.success &&
          res.url.endsWith("signup")
        ) {
          console.log("Here 2");

          this.toastr.success(res.body.message, "Registered!");
          this.router.navigate(["/signin"]);
        }
      })
    );
  }

  private saveToken(data) {
    localStorage.setItem(
      "currentUser",
      JSON.stringify({
        username: data.user.name,
        token: data.token
      })
    );
  }
}
