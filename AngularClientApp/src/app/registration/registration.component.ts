import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from 'src/app/Service/registration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm = this.fb.group({
    Name : [''],
    Lastname : [''],
    UserName : ['', Validators.required],
    Email : ['', Validators.required],
    Address : [''],
    BirthdayDate : [''],
    PassengerType : [''],
    Password : ['', Validators.required],
    ConfirmPassword : ['', Validators.required]
  });

  constructor(private fb : FormBuilder, private registrationService : RegistrationService, private router:Router) { }

  ngOnInit() {
  }

  onSubmit()
  {
    console.log(this.registerForm.value);
    this.registrationService.register(this.registerForm.value).subscribe(data => {
      console.log('Registration successfully done.');
      this.router.navigate(['/login']);
    });
  }



}
