import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
import { Observable } from 'rxjs';
import { PricelistModel } from 'src/app/model/pricelistModel';
import { AddPricelistModel } from 'src/app/model/addPricelistModel';
import { AddPricelistItemModel } from 'src/app/model/addPricelistItemModel';
import { ActivePricelistModel } from 'src/app/model/activePricelistModel';

@Injectable({
  providedIn: 'root'
})
export class PricelistSService extends HttpService{
  specificUrl = this.url + "/api/Pricelist/GetPricelist/";
  
  getPrice(ticketType : number) : Observable<any>{
    return this.http.get<any>(this.specificUrl + ticketType);
  }

  buyTicket(ticketType : number):Observable<any>{
    return this.http.post<any>(this.url + "/api/Ticket/BuyTicket/" + ticketType, null);
  }

  addPricelist(pricelist : AddPricelistModel):Observable<any>{
    let httpOptions = {
      headers:{
        "Content-type":"application/json"
      }
    }
    return this.http.post<any>(this.url + "/api/Pricelist/AddPricelist", pricelist, httpOptions);
  }

  addPricelistItem(pricelistItem : AddPricelistItemModel):Observable<any>{
    let httpOptions = {
      headers:{
        "Content-type":"application/json"
      }
    }
    return this.http.post<any>(this.url + "/api/PricelistItem/AddPricelistItem", pricelistItem, httpOptions);
  }

  getActivePricelist() : Observable<any> {
    return this.http.get<any>(this.url + "/api/PricelistItem/GetActivePricelist");
  }

  editPricelist(pricelist : ActivePricelistModel) : Observable<any>{
    let httpOptions = {
      headers:{
        "Content-type":"application/json"
      }
    }
    return this.http.post<any>(this.url + "/api/PricelistItem/UpdatePricelist", pricelist, httpOptions);
  }

}
