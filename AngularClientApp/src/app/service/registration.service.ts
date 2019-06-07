import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/service/http.service';
import { RegistrationModel } from 'src/app/model/registrationModel'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService extends HttpService{

  specificUrl = this.url + "api/Registration/PostRegistration";
  
    register(data: RegistrationModel) : Observable<any>{
      let httpOptions = {
        headers:{
          "Content-type":"application/json"
        }
      }
      return this.http.post<any>(this.specificUrl, data, httpOptions);
    }

}
