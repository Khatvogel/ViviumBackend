import React from 'react';
import ProgressBar from './ProgressBar';
import AskHint from './AskHint';
import Timer from '../Timer';

export default function Status() {
  return (
    <div className="status-page">
      <h1 className="display-4 title">Status</h1>
      <div className="container">
        <Timer />
        <div className="progression">
          <ProgressBar />
        </div>
        <AskHint />
      </div>
    </div>
  );
}
