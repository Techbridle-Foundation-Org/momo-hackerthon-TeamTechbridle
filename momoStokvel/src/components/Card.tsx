import React from "react";

export const Card: React.FC<React.PropsWithChildren<{ className?: string }>> = ({ children, className }) => {
  return (
    <div className={`rounded-lg shadow-md p-4 bg-white ${className}`}>
      {children}
    </div>
  );
};

export const CardContent: React.FC<React.PropsWithChildren<{ className?: string }>> = ({ children, className }) => {
  return <div className={`p-2 ${className}`}>{children}</div>;
};
