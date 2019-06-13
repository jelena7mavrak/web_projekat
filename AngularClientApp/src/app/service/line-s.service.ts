import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
import { LineModel } from 'src/app/model/lineModel';

@Injectable({
  providedIn: 'root'
})
export class LineSService extends HttpService {

  getLines(routeType : number) : Observable<any>{
    return this.http.get<any>(this.url + "/api/Route/GetRoute/" + routeType);
  }

  updateLine(lineData: LineModel) : Observable<any>{
    return this.http.post(this.url + "api/Line/UpdateLine", lineData);
  }

  removeLineById(lineId: number) : Observable<any>
  {
    return this.http.delete(this.url + "api/Line/RemoveLine/" + lineId);
  }
}
