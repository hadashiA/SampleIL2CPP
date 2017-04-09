def sh(command)
  puts command
  puts `#{command}`
end

# Options:
#   --configuration=<value>                         The build configuration.  Debug|Release
#   --outputpath=<value>                            Path to output the compiled binary
#   --additional-defines=<value,value,..>           Defines for generated C++ code compilation
#   --additional-libraries=<value,value,..>         One or more additional libraries to link to generated code
#   --additional-include-directories=<path,path,..> One or more additional include directories
#   --additional-link-directories=<path,path,..>    One or more additional link directories
#   --additional-cpp=<path,path,..>                 Additional C++ files to include
#   --verbose                                       Enables verbose output from tools involved in building
#   --cachedirectory=<path>                         A directory to use for caching compilation related files
#   --forcerebuild                                  Forces a rebuild
#   --compiler-flags=<value>                        Additional flags to pass to the C++ compiler
#   --linker-flags=<value>                          Additional flags to pass to the linker
#   --assembly=<path,path,..>                       One or more paths to assemblies to convert
#   --directory=<path,path,..>                      One or more directories containing assemblies to convert
#   --generatedcppdir=<path>                        The directory where generated C++ code is written
#   --data-folder=<path>                            The directory where non-source code data will be written
#   --plugin=<value,value,..>                       Path to an il2cpp plugin assembly
#   --profiler-report                               Enable generation of a profiler report
#   --convert-to-cpp                                Convert the provided assemblies to C++
#   --compile-cpp                                   Compile generated C++ code
#   --emit-null-checks                              Enables generation of null checks
#   --enable-stacktrace                             Enables generation of stacktrace sentries in C++ code at the start of every managed method. This enables support for stacktraces for platforms that do not have system APIs to walk the stack (for example, one such platform is WebGL)
#   --enable-stats                                  Enables conversion statistics
#   --enable-array-bounds-check                     Enables generation of array bounds checks
#   --enable-divide-by-zero-check                   Enables generation of divide by zero checks
#   --stats-output-dir=<path>                       The directory where statistics information will be written


unity_dir = '/Applications/Unity/Unity.app/Contents'
# unity_bin = File.join unity_dir, 'MacOS/Unity'
# mono_bin = File.join unity_dir, 'Mono/bin/mono'
mono_bin = "mono"
il2cpp_exe = File.join unity_dir, 'il2cpp/build/il2cpp.exe'

# project_dir = File.expand_path('~/dev/SampleIL2CPP')
# output_dir = File.join project_dir, 'SampleIL2CPP'
output_dir = File.expand_path('~/tmp/Hoge')

sh "#{mono_bin} #{il2cpp_exe} " <<
# "--copy-level=None " <<
# "--enable-generic-sharing " <<
# "--enable-unity-event-support " << 
# "--output-format=Compact " <<
"--convert-to-cpp " <<
# "--emit-null-checks " <<
# "--enable-array-bounds-check " <<
"--enable-symbol-loading " <<
"--development-mode " <<
# "--extra-types.file=#{unity_dir}/il2cpp/il2cpp_default_extra_types.txt " <<
# "--assembly='#{project_dir}/Temp/StagingArea/Il2Cpp/Managed/System.dll" <<
# "--assembly='#{project_dir}/Temp/StagingArea/Il2Cpp/Managed/mscorlib.dll" <<
"--assembly='Hoge.dll' " <<
"--generatedcppdir='#{output_dir}' "


