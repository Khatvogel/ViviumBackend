import React from 'react';
import ProgressBar from './ProgressBar';
import AskHint from './AskHint';
import Timer from '../Timer';

export default function Status() {
  return (
    <div className="status-page">
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
