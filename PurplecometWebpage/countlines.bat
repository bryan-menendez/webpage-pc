@echo off
Setlocal EnableDelayedExpansion
for /f "usebackq" %%a in (`dir /b /s %1`)  do (
  echo processing file %%a
  for /f "usebackq" %%b in (`type %%a ^| find "" /v /c`) do (
    echo line count is %%b
    set /a lines += %%b
    )
  )
echo total lines is %lines%