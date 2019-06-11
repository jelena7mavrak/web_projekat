import { Component, OnInit } from '@angular/core';
import { PricelistSService } from 'src/app/service/pricelist-s.service';
import { PricelistModel } from 'src/app/model/pricelistModel';

@Component({
  selector: 'app-show-prices',
  templateUrl: './show-prices.component.html',
  styleUrls: ['./show-prices.component.css']
})
export class ShowPricesComponent implements OnInit {

  price : string;

  constructor(private pricelistSservice: PricelistSService) { }

  ngOnInit() {
  }

  onSubmit(ticketType : number){
    this.pricelistSservice.getPrice(ticketType).subscribe(data => {
      console.log(data);
      this.price = data;
    });
  }

}
