import { CurrencyPipe } from '@angular/common';
import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-banking',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CurrencyPipe],
  template: `
    <p>Banking Stuff Coming Soon</p>
    <div>
      <p>Your Balance is {{ currentBalance() | currency }}</p>
    </div>
    <div>
      <input #txamount type="number" class="input input-bordered" id="amount" />
      <div>
        <button
          (click)="withdraw(txamount.valueAsNumber)"
          class="btn btn-warning"
        >
          Withdraw
        </button>
        <button
          (click)="deposit(txamount.valueAsNumber)"
          class="btn btn-primary"
        >
          Deposit
        </button>
      </div>
    </div>
  `,
  styles: ``,
})
export class BankingComponent {
  currentBalance = signal(5000);

  deposit(amount: number) {
    this.currentBalance.update((balance) => balance + amount);
  }

  withdraw(amount: number) {
    this.currentBalance.update((balance) => balance - amount);
  }
}
