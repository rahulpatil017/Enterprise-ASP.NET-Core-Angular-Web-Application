import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-healthcheck',
  templateUrl: './healthcheck.component.html',
  styleUrls: ['./healthcheck.component.css']
})
export class HealthcheckComponent implements OnInit {

  public result!: Result;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.http.get<Result>(this.baseUrl + 'hc').subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  }
}

interface Result {
  checks: Check[];
  totalStatus: string;
  totalResponseTime: number;
}

interface Check {
  name: string;
  status: string;
  responseTime: number;
  description: string;
}

