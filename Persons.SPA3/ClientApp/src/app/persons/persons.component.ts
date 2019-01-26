import { Component } from '@angular/core';

@Component({
  selector: 'persons',
  templateUrl: './persons.component.html'
})

export class PersonsComponent {
  public title = "This is my new component";

  public person = {
    FirstName: 'Dawid',
    LastName: 'Borycki',
    Age: '34',
    Email: 'dawid@borycki.com.pl'
  };


}
