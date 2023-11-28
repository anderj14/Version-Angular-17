import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { authGuard } from './core/guards/auth.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [authGuard],
    component: HomeComponent
  },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  {
    path: 'vehicles',
    canActivate: [authGuard],
    loadChildren: () => import('./vehicle/vehicle.module').then(m => m.VehicleModule)
  },
  {
    path: 'customers',
    canActivate: [authGuard],
    loadChildren: () => import('./customer/customer.module').then(m => m.CustomerModule)
  },
  {
    path: 'reservations',
    canActivate: [authGuard],
    loadChildren: () => import('./reservation/reservation.module').then(m => m.ReservationModule)
  },
  {
    path: 'invoices',
    canActivate: [authGuard, AdminGuard],
    loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule)
  },
  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },

  // Admin
  {
    path: 'admin',
    loadChildren: () => import('./admin-vehicle/admin-vehicle.module').then(m => m.AdminVehicleModule),
    data: { breadcrumb: 'Admin' }
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
