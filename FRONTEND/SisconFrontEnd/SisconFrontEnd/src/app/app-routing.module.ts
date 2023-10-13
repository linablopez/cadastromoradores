import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './component/login/login.component';
import { HomeComponent } from './component/home/home.component';
import { AuthGuard } from './auth.guard';
import { ApartamentoComponent } from './component/apartamento/apartamento.component';
import { ApartamentoDetalheComponent } from './component/apartamento-detalhe/apartamento-detalhe.component';
import { MoradorComponent } from './component/morador/morador.component';
import { MoradorDetalheComponent } from './component/morador-detalhe/morador-detalhe.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'apartamentos', canActivate: [AuthGuard], component: ApartamentoComponent },
  { path: 'apartamento/alteracao/:id', canActivate: [AuthGuard], component: ApartamentoDetalheComponent },
  { path: 'apartamento/inclusao', canActivate: [AuthGuard], component: ApartamentoDetalheComponent },
  { path: 'moradores', canActivate: [AuthGuard], component: MoradorComponent },
  { path: 'morador/alteracao/:id', canActivate: [AuthGuard], component: MoradorDetalheComponent },
  { path: 'morador/inclusao', canActivate: [AuthGuard], component: MoradorDetalheComponent },
  {
    path: 'home', component: HomeComponent, canActivate: [AuthGuard], children: [
    ]
  },
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
