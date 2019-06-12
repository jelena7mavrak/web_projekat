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

  ShowPrice(ticketType : number){
    this.pricelistSservice.getPrice(ticketType).subscribe(data => {
      console.log(data);
      this.price = data;
    });
  }

  Buy(ticketType : number){

    if(ticketType!=0)
    { 
      var obj = document.getElementById("label1");
      obj.style.display = "inline";
      obj.style.visibility = "visible";
    }
    else{ 
      this.pricelistSservice.buyTicket(ticketType).subscribe(data => {
        console.log('Ticket successfully bought!');
    });
    var obj2 = document.getElementById("label2");
      obj2.style.display = "inline";
      obj2.style.visibility = "visible";
    }
  }
}
