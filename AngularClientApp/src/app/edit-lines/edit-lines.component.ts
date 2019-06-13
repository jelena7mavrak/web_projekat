import { Component, OnInit } from '@angular/core';
import { ScheduleService } from 'src/app/service/schedule.service';
import { LineModel } from 'src/app/model/lineModel';
import { LineSService } from 'src/app/service/line-s.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-lines',
  templateUrl: './edit-lines.component.html',
  styleUrls: ['./edit-lines.component.css']
})
export class EditLinesComponent implements OnInit {

  lines : string[];
  selectedLine : string;
  lineData : LineModel = null;
  IsChecked : boolean = false;

  constructor(private scheduleService : ScheduleService, private lineService: LineSService, private router: Router) {}

  ngOnInit() {
    this.scheduleService.getAllLines().subscribe(
      data => this.lines = data
    );
  }

  onSelectionChanged(event){
    if(event.target.value != ""){
      this.selectedLine = event.target.value;
      this.scheduleService.getLineDetails(this.selectedLine).subscribe(
        data => this.lineData = data
      );
    }
  }

  onSubmit()
  {
    this.lineService.updateLine(this.lineData).subscribe(data => console.log(data));
  }

  removeLine(){
    this.lineService.removeLineById(this.lineData.Id).subscribe(data => {
      console.log(data);
      this.router.navigate(['/editlines']);
    });
  }
}
