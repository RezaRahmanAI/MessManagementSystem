import { Routes } from '@angular/router';

export const appRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/home/home.component').then((m) => m.HomeComponent)
  },
  {
    path: 'auth/login',
    loadComponent: () => import('./features/auth/login/login.component').then((m) => m.LoginComponent)
  },
  {
    path: 'auth/register',
    loadComponent: () => import('./features/auth/register/register.component').then((m) => m.RegisterComponent)
  },
  {
    path: 'onboarding/personal-info',
    loadComponent: () => import('./features/onboarding/personal-info/personal-info.component').then((m) => m.PersonalInfoComponent)
  },
  {
    path: 'onboarding/preferences',
    loadComponent: () => import('./features/onboarding/preferences/preferences.component').then((m) => m.PreferencesComponent)
  },
  {
    path: 'onboarding/complete',
    loadComponent: () => import('./features/onboarding/complete/complete.component').then((m) => m.CompleteComponent)
  },
  {
    path: 'profile',
    loadComponent: () => import('./features/profile/profile.component').then((m) => m.ProfileComponent)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
