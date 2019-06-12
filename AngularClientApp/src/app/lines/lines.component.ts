import { Component, OnInit } from '@angular/core';
import {LineSService} from 'src/app/service/line-s.service';

@Component({
  selector: 'app-lines',
  templateUrl: './lines.component.html',
  styleUrls: ['./lines.component.css']
})
export class LinesComponent implements OnInit {

  info : string;

  constructor(private lineSService : LineSService) { }

  ngOnInit() {
  }

  ShowLines(routeType : number){
    this.lineSService.getLines(routeType).subscribe(data => {
      console.log(data);
      this.info = data;
    });
  }


}
