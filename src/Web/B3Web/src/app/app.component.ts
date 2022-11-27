import { Component ,AfterViewInit, ElementRef, EventEmitter, OnInit, ViewChildren} from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators} from "@angular/forms";
import { RescueFinancial } from './models/rescue-financial.model';
import { ValueCalculate } from './models/value-calculate.model';
import { DisplayMessage, GenericValidator, ValidationMessages } from "./service/generic-form-validation"
import { InvestmentCalculationService } from './service/investment-calculation.service';
import { ToastrMessagesService } from './service/toastr-messages.service';
import {DecimalPipe} from '@angular/common';
import {MatTableDataSource} from '@angular/material/table';
import ptBr from '@angular/common/locales/pt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit, AfterViewInit{
  title = 'B3';
  formValidator: FormGroup ;
  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  valueCalculate: ValueCalculate = new ValueCalculate();
  rescueFinancial: RescueFinancial[] = [];
  displayedColumns: string[] = ['grossAmount', 'netAmount'];
  decimalPipe = new DecimalPipe('pt-BR');
  headerText: string = "";
  displayMessage: DisplayMessage = {};

  constructor(private fb: FormBuilder,
    private service: InvestmentCalculationService,
    private toastrService: ToastrMessagesService,
    ){
    this.validationMessages = {
      initialValue: {
        required: "O valor investido precisa ser maior que zero, caso o contrario o resultado sempre será zero.",
        minlength: "O valor investido precisa ter no mínimo 0,1 centavos",
      },
      month: {
        required: "O mês deve estar entre 1",
        minlength: "O mês deve ser preenchido com pelo menos 1",
      },
    };
    this.genericValidator = new GenericValidator(this.validationMessages);
    this.formValidator = this.fb.group({
      initialValue: [null,[Validators.required, Validators.min(0.1)]],
      month: [null, [Validators.required, Validators.min(1) ]],
    });
    this.genericValidator.processarMensagens(this.formValidator);
  }


  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
  }

  calculate(){
    if (this.formValidator.dirty && this.formValidator.valid) {
      this.valueCalculate = Object.assign({ValueCalculate}, this.valueCalculate, this.formValidator.value);
      this.service.calculate(this.valueCalculate).subscribe(
        {
            next: t => {
              this.rescueFinancial = [];
              this.rescueFinancial.push(t);
              console.log(this.rescueFinancial);
            },
            error: e => {
              this.rescueFinancial = [];
              this. toastrService.showError(e.error);
            }
        },
        );
    }
  }
}
