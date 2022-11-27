import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastrMessagesService {

  constructor(private toastr: ToastrService) { }

  private showMessage(type: string, title: string = "", message: string = "",
    timeOut: number = 5000) {
      let params = {
        timeOut: timeOut,
        disableTimeOut: timeOut === null
      };

      if(type === "info") {
        this.toastr.info(message, title, params)
      } else if(type === "warning") {
        this.toastr.warning(message, title, params);
      } else if(type === "error") {
        this.toastr.error(message, title, params);
      } else {
        this.toastr.success(message, title, params);
      }
  }

  showSuccess(title: string = "", message: string = "",
    timeOut: number = 5000) {
      this.showMessage('success', title, message, timeOut);
  }

  showInfo(title: string = "", message: string = "",
    timeOut: number = 5000) {
      this.showMessage('info', title, message, timeOut);
  }

  showWarning(title: string = "", message: string = "",
    timeOut: number = 5000) {
      this.showMessage('warning', title, message, timeOut);
  }

  showError(title: string = "", message: string = "",
    timeOut: number = 5000) {
      this.showMessage('error', title, message, timeOut);
  }

  handlingError(error: any, timeOut: number = 5000) {
      if(error?.error?.errorCode === "entity_validation") {
        if(error.error.notifications) {
          error.error.notifications.forEach((not: { key: string | undefined; message: string | undefined; }) => this.showMessage('error', not.key, not.message, timeOut));
        }
        this.showMessage('error', 'Ocorreram alguns erros de validação', '', timeOut);
      } else {
        this.showMessage('error', error.name, error.message, timeOut);
      }
  }
}
