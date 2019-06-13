import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
import { LineModel } from '../model/lineModel';

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

  getAllLines() : Observable<string[]>{      
    return this.http.get<string[]>(this.url + "api/Schedule/GetAllLines");
  }

  getLineDetails(lineNumber: string) : Observable<LineModel>
  {
    return this.http.get<LineModel>(this.url + "api/Schedule/GetLineData/" + lineNumber);
  }


}
