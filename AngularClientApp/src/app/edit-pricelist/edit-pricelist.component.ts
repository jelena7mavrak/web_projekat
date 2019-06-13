import { Component, OnInit } from '@angular/core';
import { ActivePricelistModel } from 'src/app/model/ActivePricelistModel';
import { PricelistSService } from 'src/app/service/pricelist-s.service';

@Component({
  selector: 'app-edit-pricelist',
  templateUrl: './edit-pricelist.component.html',
  styleUrls: ['./edit-pricelist.component.css']
})
export class EditPricelistComponent implements OnInit {

  activePricelist : ActivePricelistModel;
  
  constructor(private PricelistSService : PricelistSService) { }

  ngOnInit() {
    this.PricelistSService.getActivePricelist().subscribe(
      data=>{
          this.activePricelist = data;
    });
  }

  changePricelist(){
    console.log(this.activePricelist);
    this.PricelistSService.editPricelist(this.activePricelist).subscribe(
      result => console.log('Pricelist changed!'),
      error => console.log('Error: Pricelist can not change!')
    );
  }

}
