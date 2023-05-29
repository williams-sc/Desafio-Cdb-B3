import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  constructor(private http: HttpClient) {}

  public request<T>(
    method: string,
    path: string,
    type: string,
    data?: any
  ): Observable<T> {
    method = method.toLowerCase();
    if (
      [
        'get',
        'head',
        'post',
        'put',
        'delete',
        'connect',
        'options',
        'trace',
        'patch'
      ].indexOf(method) === -1
    ) {
      return throwError(() =>`${method} não é permitido!`);
    }

    return this._request(method, path, type, data);
  }

  private _request<T>(
    method: string,
    path: string,
    type: string,
    data?: any
  ): Observable<T> {
    const options: any = {
      body: data,
      headers: {
        'Content-Type': 'application/json',
        'Cache-Control': 'max-age=3600',
      }
    };

    return new Observable((observer: any) => {
      this.http
        .request<T>(method, `${environment.urlBase}/${path}`, options)
        .pipe(
          catchError(err => {
            return throwError(() =>err);
          })
        )
        .subscribe({
          next: (dataReq) => observer.next(dataReq),
          error: (err) =>  observer.error(err),
          complete: () => {observer.complete()}
        });
    });
  }
}