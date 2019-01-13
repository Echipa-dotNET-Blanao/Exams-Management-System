import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth/auth.component';
import { FormsModule } from '@angular/forms'

@NgModule({
  declarations: [AuthComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    AuthComponent
  ]
})

export class LoginModule { }
