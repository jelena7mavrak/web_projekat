import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
import { LoginModel } from '../model/loginModel';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService extends HttpService {

  specificUrl = this.url + "/api/Login/PostLogin";

  login(data: LoginModel) : Observable<any>{
    let httpOptions = {
      headers:{
        "Content-type":"application/json"
      }
    }
   
    return this.http.post(this.specificUrl, data, httpOptions);
  }
}
