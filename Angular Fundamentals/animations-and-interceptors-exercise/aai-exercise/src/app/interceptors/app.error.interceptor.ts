import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import {
  HttpResponse,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from "@angular/common/http";
import { tap, catchError } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";
import { Injectable } from "@angular/core";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService, private router: Router) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        switch (err.status) {
          case 401:
            this.toastr.error(err.error.message, "Warning!");
            break;
          case 400:
            this.toastr.error(err.error.message, "Warning!");
            break;
        }

        return throwError(err);
      })
    );
  }
}
