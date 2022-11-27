import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ValueCalculate } from '../models/value-calculate.model';

@Injectable({
  providedIn: 'root'
})
export class InvestmentCalculationService {

  protected baseUrl: string = `${environment.urlApi}`;

  constructor(private httpClient: HttpClient)  {

  }

  calculate(data: ValueCalculate) : Observable<any> {
    return this.httpClient.post<any>(`${this.baseUrl}investmentcalculation/calculate`, data);
  }

}
