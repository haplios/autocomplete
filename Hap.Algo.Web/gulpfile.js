/// <binding BeforeBuild='build' ProjectOpened='vite' />
/// <vs SolutionOpened='vite' />
import gulp from "gulp";
import { exec } from "gulp-execa";

gulp.task("vite", async () => {
    await exec("npm --prefix ./src/AutoComplete run dev")
});

gulp.task("build", async () => {
    await exec("npm --prefix ./src/AutoComplete run build")
});
