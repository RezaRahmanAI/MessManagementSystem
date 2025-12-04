import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-onboarding-complete',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './complete.component.html',
  styleUrl: './complete.component.css'
})
export class CompleteComponent {}
