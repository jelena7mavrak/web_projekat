import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';


@Injectable({
  providedIn: 'root'
})
export class ScheduleService extends HttpService{

  getLines(routeType : number) : Observable<any>{
    return this.http.get<any>(this.url + "/api/Schedule/GetLines1/" + routeType);
  }

  getSchedule(routeType: number, dayType: number, line: string) : Observable<any>{
    return this.http.get<any>(this.url + "/api/Schedule/GetSchedule/" + routeType + "/" + dayType + "/" + line);
  }


}
