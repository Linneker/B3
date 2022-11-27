import { HttpClient } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/compiler';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { InvestmentCalculationService } from './service/investment-calculation.service';
import { ToastrMessagesService } from './service/toastr-messages.service';

describe('AppComponent', () => {
  let investCalculation = InvestmentCalculationService;
  let http = HttpClient;
  let tst = ToastrMessagesService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        AppModule
      ],
      declarations: [
        AppComponent
      ],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents();
  });

  it('Criar aplicação', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`titulo deve ser 'B3'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('B3');
  });

});
