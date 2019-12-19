import React from 'react';
import ProgressBar from './ProgressBar';
import AskHint from './AskHint';
import Timer from '../Timer';

export default function Status() {
  return (
    <div className="container">
      <h1 class="display-4">Status</h1>
      <Timer />
      <ProgressBar />
      <AskHint />
    </div>
  );
}
