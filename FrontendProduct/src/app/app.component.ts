import { Component } from '@angular/core';
import { Meta } from '@angular/platform-browser';  

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontendProduct';

  constructor(private meta: Meta) {
    this.meta.addTags([
      { name: 'viewport', content: 'width=device-width, initial-scale=1.0' }  
    ]); 
  } 
}
