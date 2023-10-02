import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})

export class AppComponent {
  title = '7_1_6_ClientApp';
}

@Component({
  selector: 'a-comp',
  template: '<span>A Component</span>'
})
class AComponent {}