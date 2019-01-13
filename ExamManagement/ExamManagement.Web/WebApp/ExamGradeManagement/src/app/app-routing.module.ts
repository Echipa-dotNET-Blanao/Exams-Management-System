import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginModule } from './login/login.module';

const routes: Routes = [
  { path: 'login',
   component: LoginModule
  },
  {
    path: 'not-found',
    component: LoginModule
  },
  {
    path: '**',
    redirectTo: 'not-found',
    pathMatch: 'full'
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
