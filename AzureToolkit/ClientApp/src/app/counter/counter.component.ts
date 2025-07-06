import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-counter',
    templateUrl: './counter.component.html',
    standalone: false
})
export class CounterComponent implements OnInit {

  public currentCount = 0;

  constructor() { }

  ngOnInit(): void {
  }

  public incrementCounter() {
    this.currentCount++;
  }

}
