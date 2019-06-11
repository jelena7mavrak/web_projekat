import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { PricelistSService} from 'src/app/service/pricelist-s.service';
import { AddPricelistModel } from 'src/app/model/addPricelistModel';
import { AddPricelistItemModel} from 'src/app/model/addPricelistItemModel';

@Component({
  selector: 'app-pricelist',
  templateUrl: './pricelist.component.html',
  styleUrls: ['./pricelist.component.css']
})
export class PricelistComponent implements OnInit {
  addPricelistForm = this.fb.group({
    StartDate : ['', Validators.required],
    EndDate : ['', Validators.required]
  });

  addPricelistItemForm = this.fb.group({
    HourlyPrice : ['', Validators.required],
    DailyPrice : ['', Validators.required],
    MonthlyPrice : ['', Validators.required],
    AnnualPrice : ['', Validators.required]
  });

  pricelistId : number = 0;
  pricelistAdded : boolean = false;


  constructor(private fb: FormBuilder, private pricelistS : PricelistSService, private router : Router ) { }

  ngOnInit() {
  }

  addPricelist(){
    this.pricelistS.addPricelist(this.addPricelistForm.value as AddPricelistModel).subscribe(data =>
      {
        console.log(data);
        this.pricelistId = data;
        this.pricelistAdded = true;
      });
  } 

  addPricelistItem(){
    this.pricelistS.addPricelistItem(this.addPricelistItemForm.value as AddPricelistItemModel).subscribe(data =>
      { 
        console.log(data);
        this.router.navigate(['']);
      });
  }

}
