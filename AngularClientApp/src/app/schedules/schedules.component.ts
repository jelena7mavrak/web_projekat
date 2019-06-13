import { Component, OnInit } from '@angular/core';
import { ScheduleService } from 'src/app/service/schedule.service';
import { RouteType } from '../model/enums';
import { LineSService } from 'src/app/service/line-s.service';


@Component({
  selector: 'app-schedules',
  templateUrl: './schedules.component.html',
  styleUrls: ['./schedules.component.css']
})
export class SchedulesComponent implements OnInit {

  lines : string[];
  time : string;
 

  constructor(private scheduleService : ScheduleService) { }

  ngOnInit() {
  }

  ShowLines(routeType : number){
    this.scheduleService.getLines(routeType).subscribe(data => {
      console.log(data);
      this.lines = data;
    });
  }
  ShowSchedules(routeType:number, dayType: number, line:string){
    this.scheduleService.getSchedule(routeType, dayType, line).subscribe(data=>{
      console.log(data);
      this.time=data;
    });

    }
  }

