import React from 'react';
import ProgressBar from './ProgressBar';
import AskHint from './AskHint';
import Timer from '../Timer';

export default function Status() {
  return (
    <div>
      <h1 className="display-4">Status</h1>
      <div className="container">
        <Timer />
        <ProgressBar />
        <AskHint />
      </div>
    </div>
  );
}
