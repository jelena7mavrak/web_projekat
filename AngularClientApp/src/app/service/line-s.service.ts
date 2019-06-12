import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
@Injectable({
  providedIn: 'root'
})
export class LineSService extends HttpService {

  getLines(routeType : number) : Observable<any>{
    return this.http.get<any>(this.url + "/api/Route/GetRoute/" + routeType);
  }




}
